# Video Downloader
A GUI that uses the youtube-dl.exe as the engine to download videos or audio. Currently this uses the youtub-dl.exe as the engine that gets the vidio and/or audio. You will need FFMPEG package to do the conversion of the videos to mp3, ogg, m4a etc...

The purpose of this is to make it simple for people to get the content they want as everyone does not know how to use command line switches. Let face it who wants to mess around with command line all the time when you can copy/paste a link into a box and press two buttons to get your content?

This is definatly not meant to replace youtube-dl.exe, just an alternate way to get the content and still use a FREE open source utility. The ability to download or not download content depends on the youtube-dl.exe, so do not complain if something does not download or whatever.

The main repository is here: https://github.com/ytdl-org/youtube-dl

If you need the youtube-dl.exe, you can get it here(from a link on the repository): https://yt-dl.org/latest/youtube-dl.exe


November 11 2021
I have decided to open up this project to the public. This little app was more a lesson in development. 
You will FFMPEG to make this project work properly, which you can get here: https://ffmpeg.org/download.html
Currently, all files in the zip need to be downloaded and placed in a folder here: "C:\ProgramData\Media Tools\" Also the youtube-dl.exe needs to be placed in the folder there too as well. 

This app has the ability to take long fileNames and condense them to a unique one, thus preventing videos from not downloading. It removes unicode characters from file names as well. 
There are some sites that try to present 1 fideo as multiple videos of the same thing. In that case it uses the first name as all videos are exactly the same.

There is a feature that I have not currently developed which is for multiple links, that will eventually be worked on; but feel free to contribute.
