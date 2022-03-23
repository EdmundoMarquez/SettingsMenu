# Settings Menu for Unity
![1](/SettingsMenu/Images/cover.png)

## To Install

Download the [.unitypackage](https://www.dropbox.com/s/w7rce3dpkoseswg/unity-settings-menu-1.0.unitypackage), or clone this repository.

If you downloaded the .unitypackage:
1. Install Newtonson Json package from Unity Registry (Window > Package Manager > Unity Registry)
2. Install Text Mesh Pro essential resources (Window > TextMeshPro > Import TMP Essential Resources)
3. Import the unity package (Assets > Import Package > Custom package...)

## To Use

![1](/SettingsMenu/Images/howto_0.png)

1. Open the sample scene located in Demo/Scenes
2. Duplicate this scene and load it in your project's build settings
3. You can change the character inside Environment and adjust the camera preview

![1](/SettingsMenu/Images/howto_2.png)

Note: To set native resolution in your build, change the resolution index in Data/Saved/Saved Preferences to -1. 
(This will only work in builds, use 0 while in the editor instead)

## To Customize
All configurations are stored inside Data

- Fonts

![fonts](/SettingsMenu/Images/custom_0.png)

You can change the serif, sans serif and open dyslexic presets with Text Mesh Pro Font Assets. You can also manipulate the size of small, medium and large size configurations.

- Localization

![fonts](/SettingsMenu/Images/custom_4.png)

Language data is stored in text asset data assets used to convert json files to texts. To modify the texts, go to Data/Localization/Json. Note that these files use the following syntax "id" : "text", "id"s should not be modified but "text"s can be. Alternatively you can create new ids and use this same file for other menus and dialogues (see Dropdowns and Localized Text).   

- Dropdowns

![fonts](/SettingsMenu/Images/custom_1.png)

![fonts](/SettingsMenu/Images/custom_2.png)

Dropdown data from the settings menu can be modified here. Note that there are localized dropdowns and regular dropdowns. Localized dropdowns must use ids from the json files if you want it to work as intended. Regular dropdowns are used for texts that don't need translation and you can write the text as it is.

- Accesible Text

![1](/SettingsMenu/Images/components_0.png)

Any text in the scene can be change by the font settings if you add UI Accesible Text. It only requires an id and the Text Mesh Pro text. For dropdowns just add the same component and target the item label as your text. This component should be added in gameobjects that will be active in the scene, otherwise they will not work. If you want to hide a UI element, use Canvas Groups instead.

- Localized Text

![1](/SettingsMenu/Images/components_1.png)

Any text in the scene can be localized if you add UI Localized Text component. It only requires an id and the Text Mesh Pro text. For special cases, such as dropdowns, you need to add UI Localized Dropdown component and load it in the Scripts/Settings classes. These components should be added in gameobjects that will be active in the scene, otherwise they will not work. If you want to hide a UI element, use Canvas Groups instead.


