# AlienBeacon
An RGB LED strip controller that runs color programs off an SD card.

[![Watch the video](https://github.com/evankale/AlienBeacon/blob/master/video.jpg?raw=true)](http://http://youtu.be/Ncz0Ewp892c)

Watch the video: http://youtu.be/Ncz0Ewp892c

Power
======

The Alien Beacon requires 12V DC power.
Like so, https://amzn.to/2PysluX

5-16V works too, as long as the input power matches the requirement of the LED strip.

When choosing the correct power rating for an LED strip, a good rule of thumb is to choose an adapter that is rated for 1A for every 300 pieces of 12V RGB LEDs.

LEDs
====

The default LED strip pin order is BRGV. Although, the channel order outputs can be set to any order using the Alien Bacon to create color programs.

Here is an example of a 12V RGB LED strip: https://amzn.to/2EjsRLJ


Customization
=============

Custom color programs are created using the Alien Bacon.
You can find and run the program in the AlienBacon/bin folder (or build from source in the AlienBacon/src folder).

How to use:
Image colors - Lets you choose an image to automatically pick out the dominant colors.
Color sequence - Lets you choose a directory of images to combine into one program (the average color of each image in the folder will be used).
Frame delay - Sets the delay time between every frame.
Preview - Hit Play to see a preview of the colors cycling.
Save - Save the program to file, and choose the channel output order.

A quick demo can be seen here: http://youtu.be/Ncz0Ewp892c

