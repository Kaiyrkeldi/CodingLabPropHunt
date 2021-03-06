using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum PlayerClass {first, second, propVegetableBasket,basket,mug, cup, skin, box, chair, pillow};

public class PlayerInfoMessage: MessageBase {

  public static short msgType= MsgType.Highest + 1;
  public PlayerClass playerClass;

  public PlayerInfoMessage (PlayerClass playerClass) {
    this.playerClass = playerClass;
  }
  public PlayerInfoMessage(){}
}