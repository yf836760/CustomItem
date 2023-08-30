﻿using TerrariaApi.Server;
using Terraria;
using TShockAPI;

namespace CustomItem;

[ApiVersion(2, 1)]
public class CustomItem : TerrariaPlugin
{

    public override string Name => "CustomItem Plugin";
    public override Version Version => new Version(1, 0, 0);
    public override string Author => "yf836760";
    public override string Description => "Custom item like weapons in terraria";


    public static string Specifier
    {
        get { return string.IsNullOrWhiteSpace(TShock.Config.Settings.CommandSpecifier) ? "/" : TShock.Config.Settings.CommandSpecifier; }
    }
    /// <summary>
    /// The plugin's constructor
    /// Set your plugin's order (optional) and any other constructor logic here
    /// </summary>
    public CustomItem(Main game) : base(game)
    {

    }

    /// <summary>
    /// Performs plugin initialization logic.
    /// Add your hooks, config file read/writes, etc here
    /// </summary>
    public override void Initialize()
    {
        Commands.ChatCommands.Add(new Command(
            new List<string> {"ci.admin"},
            this.Cmd,
            "ci"
        ));
        //throw new NotImplementedException();
    }

    private void Cmd(CommandArgs args)
    {
        var tsPlayer = args.Player;
        var tPlayer = args.TPlayer;
        var param = args.Parameters;
        var paramCount = args.Parameters.Count;
        List<int> intParamList;
        CustomItemRecord customItemRecord;

        switch (paramCount)
        {
            case 0: tsPlayer.SendErrorMessage("Useage Guide: {0}ci itemID damageValue projectileID knockbackValue useTimeValue projectileSpeedValue \t optional parameters: int UseAmmo = 0, int Ammo = 0, int Amount = 1, int Scale = 1, int UseAnimation = 15 ", Specifier); break;
            case 6 when param.All(element => int.TryParse(element, out _)): 
                intParamList = param.Select(s => int.Parse(s)).ToList(); 
                customItemRecord = new CustomItemRecord(intParamList[0], intParamList[1], intParamList[2], intParamList[3], intParamList[4], intParamList[5]);  
                CreateCustomItem(customItemRecord, tsPlayer);
                break;
            case 7 when param.All(element => int.TryParse(element, out _)): 
                intParamList = param.Select(s => int.Parse(s)).ToList(); 
                customItemRecord = new CustomItemRecord(intParamList[0], intParamList[1], intParamList[2], intParamList[3], intParamList[4], intParamList[5], intParamList[6]);  
                CreateCustomItem(customItemRecord, tsPlayer);
                break;
            case 8 when param.All(element => int.TryParse(element, out _)): 
                intParamList = param.Select(s => int.Parse(s)).ToList(); 
                customItemRecord = new CustomItemRecord(intParamList[0], intParamList[1], intParamList[2], intParamList[3], intParamList[4], intParamList[5], intParamList[6], intParamList[7]);  
                CreateCustomItem(customItemRecord, tsPlayer);
                break;
            case 9 when param.All(element => int.TryParse(element, out _)): 
                intParamList = param.Select(s => int.Parse(s)).ToList(); 
                customItemRecord = new CustomItemRecord(intParamList[0], intParamList[1], intParamList[2], intParamList[3], intParamList[4], intParamList[5], intParamList[6], intParamList[7], intParamList[8]);   
                CreateCustomItem(customItemRecord, tsPlayer);
                break;
            case 10 when param.All(element => int.TryParse(element, out _)): 
                intParamList = param.Select(s => int.Parse(s)).ToList(); 
                customItemRecord = new CustomItemRecord(intParamList[0], intParamList[1], intParamList[2], intParamList[3], intParamList[4], intParamList[5], intParamList[6], intParamList[7], intParamList[8], intParamList[9]);  
                CreateCustomItem(customItemRecord, tsPlayer);
                break;
            case 11 when param.All(element => int.TryParse(element, out _)): 
                intParamList = param.Select(s => int.Parse(s)).ToList(); 
                customItemRecord = new CustomItemRecord(intParamList[0], intParamList[1], intParamList[2], intParamList[3], intParamList[4], intParamList[5], intParamList[6], intParamList[7], intParamList[8], intParamList[9], intParamList[10]);  
                CreateCustomItem(customItemRecord, tsPlayer);
                break;   
            default : break;
        }
        
    }
    public record CustomItemRecord(int ItemID, int Damage, int Shoot, int KnockBack, int UseTime, int ShootSpeed, int UseAmmo = 0, int Ammo = 0, int Amount = 1, int Scale = 1, int UseAnimation = 15);

    private void CreateCustomItem(CustomItemRecord customItemRecord, TSPlayer tSPlayer)
        {
            int itemID = customItemRecord.ItemID;
            int amount = customItemRecord.Amount;
            Item customItem = TShock.Utils.GetItemById(itemID);
            int itemIndex = Item.NewItem(tSPlayer.TPlayer.GetItemSource_OpenItem(itemID), (int)tSPlayer.X, (int)tSPlayer.Y, customItem.width, customItem.height, customItem.type, amount);
            Item targetItem = Main.item[itemIndex];
            targetItem.playerIndexTheItemIsReservedFor = tSPlayer.Index;
            targetItem.damage = customItemRecord.Damage;
            targetItem.shoot = customItemRecord.Shoot;
            targetItem.knockBack = customItemRecord.KnockBack;
            targetItem.useTime = customItemRecord.UseTime;
            targetItem.shootSpeed = customItemRecord.ShootSpeed;
            targetItem.scale = customItemRecord.Scale;
            targetItem.ammo = customItemRecord.Ammo;
            targetItem.useAnimation = customItemRecord.UseAnimation;
            targetItem.useAmmo = customItemRecord.UseAmmo;
            TSPlayer.All.SendData(PacketTypes.UpdateItemDrop, null, itemIndex);
            TSPlayer.All.SendData(PacketTypes.ItemOwner, null, itemIndex);
            TSPlayer.All.SendData(PacketTypes.TweakItem, null, itemIndex, 255, 63);
        }
        
    /// <summary>
    /// Performs plugin cleanup logic
    /// Remove your hooks and perform general cleanup here
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            //unhook
            //dispose child objects
            //set large objects to null
        }
        base.Dispose(disposing);
    }
}