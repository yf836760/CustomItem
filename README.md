# CustomItem
A TShock plugin for cutoming items like weapons in terraria
## Build it
Install dotnet sdk, for example(Windows 11): `winget install Microsoft.DotNet.SDK.6`

Clone this project: `git clone https://github.com/yf836760/CustomItem.git`

Build it in the project folder: `dotnet build`

By default, the release file `CustomItem.dll` is in CustomItem/bin/Debug/net6.0/ folder
## Useage Guide 
`/ci itemID damageValue projectileID knockbackValue useTimeValue projectileSpeedValue` (UseAmmo = 0, Ammo = 0, Amount = 1, Scale = 1, UseAnimation = 15)
## Command Example
`/ci 24 250 16 12 10 15` 👈a tree sword that can shot a projectile that ID is 16, damage is 250, knockback value is 12, usetime is 10 projectile speed is 15

`/ci 2481 250 16 12 10 15 0 40` 👈a item that ID is 2481, not consume ammo, as a ammo that id is 40
