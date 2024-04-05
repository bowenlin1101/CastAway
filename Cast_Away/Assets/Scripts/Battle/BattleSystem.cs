using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState
{
    Start, PlayerAction, PlayerAttack, PlayerAct, AlienMove, Busy, PlayerDefend, PlayerSpare, PlayerItem
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] KeyCode ConfirmKey;
    [SerializeField] KeyCode RejectKey;

    [SerializeField] PlayerBattleHud playerHud;
    [SerializeField] PlayerBattleUnit playerUnit;
    [SerializeField] AlienBattleHud alienHud;
    [SerializeField] AlienBattleUnit alienUnit;
    [SerializeField] BattleDialogBox dialogBox;
    [SerializeField] DefendSystem defendSystem;
    [SerializeField] DetectHit playerCollider;
    [SerializeField] GameObject fist;
    [SerializeField] GameObject acid;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject penny;
    [SerializeField] GameObject needle;
    [SerializeField] GameObject badnews;
    [SerializeField] GameObject sword;
    BattleState state;
    int currentAction;
    int currentAttack;
    int currentItem;
    int currentAct;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        //Setup Player
        playerUnit.Setup();
        playerHud.SetData(playerUnit.player);
        //Setup Alien
        alienUnit.Setup();
        alienHud.SetData(alienUnit.alien);

        dialogBox.EnableDialogText(true);
        dialogBox.EnableActionSelector(true);
        dialogBox.EnableAttackSelector(false);
        dialogBox.EnableActSelector(false);
        dialogBox.EnableDefendSystem(false);
        dialogBox.EnableItemSelector(false);

        //Setup Moves
        dialogBox.SetAttackNames(playerUnit.player.attacks);

        //Setup Acts
        dialogBox.SetActNames(alienUnit.alien.acts);

        //Setup items
        dialogBox.SetItemNames(playerUnit.player.items);



        //Run dialog Text
        yield return dialogBox.TypeDialog($"You were stopped by {alienUnit.alien.Species}!");
        //Wait for a second
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
        dialogBox.EnableDialogText(true);
        dialogBox.EnableAttackSelector(false);
        dialogBox.EnableActSelector(false);
        dialogBox.EnableItemSelector(false);
    }

    void PlayerAttack()
    {
        state = BattleState.PlayerAttack;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableAttackSelector(true);
        currentAttack = 0;
    }

    void PlayerSpare()
    {
        state = BattleState.PlayerSpare;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(true);
        dialogBox.EnableAttackSelector(false);
        currentAttack = 0;
    }

    void PlayerDefend()
    {
        state = BattleState.PlayerDefend;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableDefendSystem(true);
    }

    void PlayerItem()
    {
        state = BattleState.PlayerItem;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableItemSelector(true);
    }

    IEnumerator PerformPlayerSpare()
    {
        state = BattleState.Busy;

        yield return dialogBox.TypeDialog($"{playerUnit.player.Name} tries to Spare {alienUnit.alien.Species}");
        yield return new WaitForSeconds(1f);

        bool isPacified = alienUnit.alien.Aggression == 0;

        if (isPacified)
        {
            yield return dialogBox.TypeDialog($"{alienUnit.alien.Species} has been Spared!");

            if (alienUnit.alien is SuperiorAlienScript)
            {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"You have shown me the errors of my ways"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"More blood will not help me mourn the loss of my citizens"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"Perhaps... There has been a mistake"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"You are free to go..."));
            }

            HandleAlienDefeat(false);
        }
        else
        {
            yield return dialogBox.TypeDialog($"{alienUnit.alien.Species} is currently too Aggressive to be Spared!");
            yield return new WaitForSeconds(1f);
            StartCoroutine(AlienAttackPart1());
        }
    }

    IEnumerator PerformPlayerAttack()
    {
        state = BattleState.Busy;

        var attack = playerUnit.player.attacks[currentAttack];

        yield return dialogBox.TypeDialog($"{playerUnit.player.Name} used {attack.AttackName}");
        yield return new WaitForSeconds(1f);
        bool isDead;
        if (alienUnit.alien.Aggression == 0)
        {
            isDead = alienUnit.alien.TakeDamage(new Attack("Insta-Kill", 1000, "Detrimental"));
        }
        else
        {
            isDead = alienUnit.alien.TakeDamage(attack);
        }

        yield return alienHud.UpdateHP();
        if (isDead)
        {
            yield return dialogBox.TypeDialog($"{alienUnit.alien.Species} is no longer moving...");

            if (alienUnit.alien is SuperiorAlienScript)
            {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"Looks like you bested me..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"I'm sorry, my people."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"I am not strong enough to protect you"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"Though we may look like monsters"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"YOU ARE THE REAL MONSTER"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"..."));
            }
            GameManager.Instance.aliensKilled++;
            HandleAlienDefeat(true);
        }
        else
        {
            StartCoroutine(AlienAttackPart1());
        }
    }

    IEnumerator PerformPlayerAct()
    {
        state = BattleState.Busy;

        var act = alienUnit.alien.acts[currentAct];
        yield return dialogBox.TypeDialog($"{playerUnit.player.Name} used {act.MoveName}");
        yield return new WaitForSeconds(1f);
        yield return dialogBox.TypeDialog(act.Description);
        yield return new WaitForSeconds(1f);

        var (isPacified, message) = alienUnit.alien.TakePacify(act);
        yield return dialogBox.TypeDialog(message);
        yield return new WaitForSeconds(1f);

        yield return alienHud.UpdateA();
        if (isPacified)
        {
            yield return dialogBox.TypeDialog($"{alienUnit.alien.Species} no longer wants to fight and is ready to be spared");
            yield return new WaitForSeconds(1f);

            //TODO
            PlayerAction();
        }
        else
        {
            StartCoroutine(AlienAttackPart1());
        }
    }

    IEnumerator PerformPlayerItem()
    {
        state = BattleState.Busy;

        var item = playerUnit.player.items[currentAct];
        yield return dialogBox.TypeDialog($"{playerUnit.player.Name} used {item.name}");
        yield return new WaitForSeconds(1f);
        yield return dialogBox.TypeDialog($"{playerUnit.player.Name} healed {((HealthPotion)item).hpHealed}");

        playerUnit.player.TakeDamage(-((HealthPotion)item).hpHealed);
        yield return new WaitForSeconds(1f);

        yield return playerHud.UpdateHP();
        if (alienUnit.alien.Aggression == 0)
        {
            yield return dialogBox.TypeDialog($"{alienUnit.alien.Species} no longer wants to fight and is ready to be spared");
            yield return new WaitForSeconds(1f);

            //TODO
            PlayerAction();
        }
        else
        {
            StartCoroutine(AlienAttackPart1());
        }
        Inventory.instance.items.Remove(item);
        playerUnit.player.items.Remove(item);
        dialogBox.SetItemNames(playerUnit.player.items);
    }

    IEnumerator AlienAttackPart1()
    {
        state = BattleState.AlienMove;

        var attack = alienUnit.alien.generateAttack();
        switch (attack.Sprite)
        {
            case "Fist":
                GameManager.Instance.projectile = fist;
                break;
            case "Acid":
                GameManager.Instance.projectile = acid;
                break;
            case "Wall":
                GameManager.Instance.projectile = wall;
                break;
            case "Needle":
                GameManager.Instance.projectile = needle;
                break;
            case "BadNews":
                GameManager.Instance.projectile = badnews;
                break;
            case "Penny":
                GameManager.Instance.projectile = penny;
                break;

        }
        yield return dialogBox.TypeDialog($"{alienUnit.alien.Species} used {attack.AttackName}");
        yield return new WaitForSeconds(1f);

        defendSystem.Start();
        defendSystem.MoveToRow(1);
        playerCollider.hits = 0;
        //depends on alien attack
        defendSystem.SetDifficulty(attack.NumberOfAttacks, attack.Speed, attack.Interval, attack);
        PlayerDefend();
    }

    IEnumerator AlienAttackPart2()
    {
        yield return new WaitForSeconds(2.5f);

        state = BattleState.AlienMove;
        dialogBox.EnableDefendSystem(false);
        dialogBox.EnableDialogText(true);

        StartCoroutine(dialogBox.TypeDialog($"You dodged {defendSystem.numberOfAttacks * (defendSystem.attackPattern + 1) - playerCollider.hits}/{defendSystem.numberOfAttacks * (defendSystem.attackPattern + 1)} hits"));
        yield return new WaitForSeconds(2f);

        Attack attack = defendSystem.attack;

        int numberOfAttacks = defendSystem.numberOfAttacks;
        float damage = attack.Damage / numberOfAttacks * playerCollider.hits;

        bool isDead = playerUnit.player.TakeDamage(damage);
        yield return playerHud.UpdateHP();
        if (isDead)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.player.Name} Died");

            Debug.Log("Brosky");
            yield return new WaitForSeconds(2.5f);
            PlayerMovement.instance.Respawn(GameManager.Instance.currentScene);
        }
        else
        {
            PlayerAction();
        }
    }

    void PlayerAct()
    {
        state = BattleState.PlayerAct;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActSelector(true);
        currentAct = 0;
    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerAttack)
        {
            HandleAttackSelection();
        }
        else if (state == BattleState.PlayerAct)
        {
            HandleActSelection();
        }
        else if (state == BattleState.PlayerDefend)
        {
            HandleDefend();
        }
        else if (state == BattleState.PlayerSpare)
        {
            StartCoroutine(PerformPlayerSpare());
        }
        else if (state == BattleState.PlayerItem)
        {
            HandleItemSelection();
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAction < 4 - 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 4 - 2)
                currentAction += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 1)
                currentAction -= 2;
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(ConfirmKey))
        {
            if (currentAction == 0)
            {
                //Fight
                PlayerAttack();
            }
            else if (currentAction == 1)
            {
                //Act
                PlayerAct();
            }
            else if (currentAction == 2)
            {
                //Item
                PlayerItem();
            }
            else if (currentAction == 3)
            {
                //Spare
                PlayerSpare();
            }
        }
    }


    void HandleActSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAct < alienUnit.alien.acts.Count - 1)
                ++currentAct;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAct > 0)
                --currentAct;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAct < alienUnit.alien.acts.Count - 2)
                currentAct += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAct > 1)
                currentAct -= 2;
        }

        if (Input.GetKeyDown(RejectKey))
        {
            PlayerAction();
        }

        dialogBox.UpdateActSelection(currentAct, alienUnit.alien.acts[currentAct]);

        if (Input.GetKeyDown(ConfirmKey))
        {
            dialogBox.EnableActSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerAct());
        }
    }


    void HandleAttackSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAttack < playerUnit.player.attacks.Count - 1)
                ++currentAttack;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAttack > 0)
                --currentAttack;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAttack < playerUnit.player.attacks.Count - 2)
                currentAttack += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAttack > 1)
                currentAttack -= 2;
        }

        if (Input.GetKeyDown(RejectKey))
        {
            PlayerAction();
        }

        dialogBox.UpdateAttackSelection(currentAttack, playerUnit.player.attacks[currentAttack]);

        if (Input.GetKeyDown(ConfirmKey))
        {
            dialogBox.EnableAttackSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerAttack());
        }
    }

    void HandleItemSelection()
    {
        if (playerUnit.player.items.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentItem < playerUnit.player.items.Count - 1)
                    ++currentItem;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentItem > 0)
                    --currentItem;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentItem < playerUnit.player.items.Count - 2)
                    currentItem += 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentItem > 1)
                    currentItem -= 2;
            }

            dialogBox.UpdateItemSelection(currentItem, playerUnit.player.items[currentItem]);
            if (Input.GetKeyDown(ConfirmKey))
            {
                dialogBox.EnableItemSelector(false);
                dialogBox.EnableDialogText(true);
                StartCoroutine(PerformPlayerItem());
            }
        }
        if (Input.GetKeyDown(RejectKey))
        {
            PlayerAction();
        }
    }

    void HandleDefend()
    {
        var rows = defendSystem.rows;
        var currentRowIndex = defendSystem.currentRowIndex;
        var switchTimer = defendSystem.switchTimer;
        var switchCooldown = defendSystem.switchCooldown;
        var macroSpawnInterval = defendSystem.macroSpawnInterval;
        var microSpawnInterval = defendSystem.microSpawnInterval;
        var numberPerMicroInterval = defendSystem.numberPerMicroInterval;
        var macroSpawnTimer = defendSystem.macroSpawnTimer;
        var microSpawnTimer = defendSystem.microSpawnTimer;
        //Moving the avatar
        defendSystem.switchTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentRowIndex < rows.Length - 1 && switchTimer >= switchCooldown)
        {
            defendSystem.MoveToRow(currentRowIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentRowIndex > 0 && switchTimer >= switchCooldown)
        {
            defendSystem.MoveToRow(currentRowIndex - 1);
        }

        //Spawn projectiles
        defendSystem.macroSpawnTimer += Time.deltaTime;
        if (defendSystem.numberThrown != defendSystem.numberOfAttacks)
        {
            if (macroSpawnTimer >= macroSpawnInterval && defendSystem.numberThrown < defendSystem.numberOfAttacks)
            {
                defendSystem.microSpawnTimer += Time.deltaTime;
                if (microSpawnTimer >= microSpawnInterval && defendSystem.numberMicroThrown < defendSystem.numberPerMicroInterval)
                {

                    if (defendSystem.attackPattern == 0)
                    {
                        defendSystem.SpawnSingleProjectile();
                    }
                    else if (defendSystem.attackPattern == 1)
                    {
                        defendSystem.SpawnDoubleProjectile();
                    }
                    else
                    {
                        StartCoroutine(defendSystem.SpawnBurstProjectile());
                    }
                    defendSystem.microSpawnTimer = 0;
                    defendSystem.numberMicroThrown++;

                }
                else if (defendSystem.numberMicroThrown == defendSystem.numberPerMicroInterval)
                {
                    Debug.Log("new interval");
                    defendSystem.macroSpawnTimer = 0;
                    defendSystem.numberMicroThrown = 0;
                    defendSystem.microSpawnTimer = 0;
                }
            }
        }
        else
        {
            defendSystem.numberThrown++;
            StartCoroutine(AlienAttackPart2());
        }
    }

    public void HandleAlienDefeat(bool dead)
    {
        if (dead) {
            if (GameManager.Instance.alienName == "CitizenAlien1") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "*huff* *puff*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "You... traitor..."));
            } else if (GameManager.Instance.alienName == "CitizenAlien2") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "*cough* *cough*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "this is how you repay us?..."));
            } else if (GameManager.Instance.alienName == "CitizenAlien3") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "you... won't..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "get away.... with this...."));
            } else if (GameManager.Instance.alienName == "CitizenAlien4") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "Forgive me Claire..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "take care of our child...."));
            } else if (GameManager.Instance.alienName == "CitizenAlien5") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "we... shouldn't have..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "trusted... YOU..."));
            } else if (GameManager.Instance.alienName == "DoctorAlien1") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "my *cough* diagnosis... *cough*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "is *cough* *cough*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "YOU WILL PERISH"));

            } else if (GameManager.Instance.alienName == "DoctorAlien2") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "my *cough* diagnosis... *cough*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "is *cough* *cough*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "YOU WILL PERISH"));

            } else if (GameManager.Instance.alienName == "DoctorAlien3") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "you dirty backstabber..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "you'll *huff* *cough*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "get what's coming..."));

            } else if (GameManager.Instance.alienName == "DoctorAlien4") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "my *cough friends will *puff* avenge me..."));
            } else if (GameManager.Instance.alienName == "DoctorAlien5") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "you RASCAL... *pant*"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "you'll die to what's up ahead :)"));
            }

        } else {
            if (GameManager.Instance.alienName == "CitizenAlien1") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "You're not so bad after all :)"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "...What's that supposed to mean?"));
            } else if (GameManager.Instance.alienName == "CitizenAlien2") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "I love discussing hating taxes :P"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Same here!"));
            } else if (GameManager.Instance.alienName == "CitizenAlien3") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "Sometimes you need a little tough love :D"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "That's what I mean"));
            } else if (GameManager.Instance.alienName == "CitizenAlien4") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "We were right about humans!"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Right about what?"));
            } else if (GameManager.Instance.alienName == "CitizenAlien5") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "Compliments make my heart flutter > w <"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Woah woah. I'm taken... sorry..."));
            } else if (GameManager.Instance.alienName == "DoctorAlien1") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "A worthy opponent you are"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "As were you"));

            } else if (GameManager.Instance.alienName == "DoctorAlien2") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "So... if I do 10 pushups a day, I'll have veins like those?"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", ".... Yeah... sure bud"));

            } else if (GameManager.Instance.alienName == "DoctorAlien3") {
                 ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "Is your leg better?"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Yeah"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "Cool! Catch ya later alligator ;)"));
            } else if (GameManager.Instance.alienName == "DoctorAlien4") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "We do not regret this :)"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "...Regret what?"));

            } else if (GameManager.Instance.alienName == "DoctorAlien5") {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "Our boss is up ahead!"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "I'm sure he'll like you"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Boss...?"));

            }
        }
        alienUnit.transform.eulerAngles = new Vector3(0, 0, 90);
        GameManager.Instance.movementLocked = false;
        SceneManager.LoadScene(GameManager.Instance.currentScene);
    }
}