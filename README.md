# 7-Segment Display
## Description
This is a **VB.NET WinForms Control** (.dll).<br>
![ControlPreview](https://dl.dropboxusercontent.com/s/9ytak1vcg684m2y/SevenSegDisplay.png)
<br>The library is called **SevenSegmentsDisplay**. It doesn't necessarily make much sense, given that we can use fonts with a "digital style". But **I wanted to do this myself**, in a way that is not necessarily the best, of course!<br>**I accept the recommendations but I won't force myself to make changes**...

A [demo form](https://github.com/Drarig29/7-SegmentDisplay/tree/master/Demo) is included so you can easily see how it works.<br><br>
![DemoFormPreview](https://dl.dropboxusercontent.com/s/1b59ju3pcx91fqn/DemoForm.png)

##Properties
It has mainly 6 properties :<br>
* **Value** - The value to display.
* **Digits** - The number of digits.
* **BorderStyle** - The segments border style.
* **SegmentOnColor** - Activated segments' color.
* **HideOffSegments** - Hide or not deactivated segments.
* **SegmentOffColor** - Deactivated segments' color.

##Events
Of course, it has events :
* **ValueChanged** - Fired when Value property is changed.
* **DigitsChanged** - Fired when Digits property is changed.
* **BorderStyleChanged** - Fired when BorderStyle property is changed.
* **HideOffSegmentsChanged** - Fired when HideOffSegments property is changed.
* **SegmentsOnColorChanged** - Fired when SegmentsOnColor property is changed.
* **SegmentsOffColorChanged** - Fired when SegmentsOffColor property is changed.

`Public Event ValueChanged As EventHandler`<br>
`Public Event DigitsChanged As EventHandler`<br>
`Public Event BorderStyleChanged As EventHandler`<br>
`Public Event HideOffSegmentsChanged As EventHandler`<br>
`Public Event SegmentsOnColorChanged As EventHandler`<br>
`Public Event SegmentsOffColorChanged As EventHandler`<br>

##SmartTags
It also has [SmartTags](https://msdn.microsoft.com/en-us/library/ms171829.aspx?f=255&MSPPError=-2147217396), which makes it **very intuitive at Design Time**.<br><br>
![SmartTagsPreview](https://dl.dropboxusercontent.com/s/l59bdn8vig348ae/SmartTags.png)

##How to use
To use this control, [download it](https://raw.githubusercontent.com/Drarig29/7-SegmentDisplay/master/SevenSegDisplay/bin/Release/SevenSegDisplay.dll), and **add it to the Toolbox** :<br>
* Right-click on the Toolbox,
* Select "Choose Items...",
* Wait for the loading, and click "Browse...",
* Choose the control (.dll file),
* Click OK, then it's added to Toolbox.

##About
**Latest version** : 2.5<br><br>
Good use!<br>
If you have problems, you can [contact me](mailto:corentinleguitariste@hotmail.fr).
