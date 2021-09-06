# 7-Segment Display

## Description

This is a **VB.NET WinForms Control** (.dll).

The library is called **SevenSegmentsDisplay**. It doesn't necessarily make much sense, given that we can use fonts with a "digital style". But **I wanted to do this myself**, in a way that is not necessarily the best, of course!

**I accept the recommendations but I won't force myself to make changes**...

A [demo form](https://github.com/Drarig29/7-SegmentDisplay/tree/master/Demo) is included so you can easily see how it works.

## Properties

It has mainly 6 properties :

* **Value** - The value to display.
* **Digits** - The number of digits.
* **BorderStyle** - The segments border style.
* **SegmentOnColor** - Activated segments' color.
* **HideOffSegments** - Hide or not deactivated segments.
* **SegmentOffColor** - Deactivated segments' color.

## Events

Of course, it has events :

* **ValueChanged** - Fired when Value property is changed.
* **DigitsChanged** - Fired when Digits property is changed.
* **BorderStyleChanged** - Fired when BorderStyle property is changed.
* **HideOffSegmentsChanged** - Fired when HideOffSegments property is changed.
* **SegmentsOnColorChanged** - Fired when SegmentsOnColor property is changed.
* **SegmentsOffColorChanged** - Fired when SegmentsOffColor property is changed.

## SmartTags

It also has [SmartTags](https://docs.microsoft.com/en-us/previous-versions/ms171829(v=vs.140)), which makes it **very intuitive at Design Time**.

## How to use

To use this control, [download it](https://raw.githubusercontent.com/Drarig29/7-SegmentDisplay/master/SevenSegDisplay/bin/Release/SevenSegDisplay.dll), and **add it to the Toolbox** :

* Right-click on the Toolbox,
* Select "Choose Items...",
* Wait for the loading, and click "Browse...",
* Choose the control (.dll file),
* Click OK, then it's added to Toolbox.
