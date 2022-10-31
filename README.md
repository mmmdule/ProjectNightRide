# ProjectNightRide
Project Night Ride - Volume One

Project Night Ride is a video-game inspired by the music and aesthetics of the Serbian music group Fantom.

## TODO List
- Use sprite atlases to try and have less draw calls to improve performance
  - https://gamedevelopment.tutsplus.com/articles/using-texture-atlas-in-order-to-optimize-your-game--cms-26783
  - https://docs.unity3d.com/2022.2/Documentation/Manual/class-SpriteAtlas.html
  
- Perform static batching for static objects (traffic cones, coins in even numbered levels). Use the information at: https://docs.unity3d.com/Manual/static-batching.html~~

## Best build settings (so far)

### Mid size, but great performance
- ETC2
- 16-bit (ETC2 fallback)
- LZ4HC (compression)

### Best size, but mid-to-bad perfomance (especially on Nikola's phone)
- ASTC
- 16-bit (ETC2 fallback)
- LZ4HC (compression)

***

## Side-notes
- Older versions (named "Latest Stable" and "Older Stable Build") are placed together inside a .7z archive and uploaded on the borprog209 account. They were deleted from the local machine to free up disk space
