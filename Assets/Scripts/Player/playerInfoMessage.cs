using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

<<<<<<< HEAD
public enum PlayerClass {first, second, propVegetableBasket,basket,mug};
=======
public enum PlayerClass {first, second, propVegetableBasket,basket,mug,cup,skin,box,chair,pillow};
>>>>>>> 399dc667145c7b86349a0c5f3429be9c6a8bf1cf

public class PlayerInfoMessage: MessageBase {

  public static short msgType= MsgType.Highest + 1;
  public PlayerClass playerClass;

  public PlayerInfoMessage (PlayerClass playerClass) {
    this.playerClass = playerClass;
  }
  public PlayerInfoMessage(){}
}