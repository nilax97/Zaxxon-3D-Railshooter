FREE TURRET SCRIPT
by problemecium

Use:
- Build a turret using game objects; examples can be found in the demo scenes. Make sure that discrete game objects exist for each of the moving parts in the turret, e.g. the base, swivel mount, and barrel.
- Attach the Turret script to any GameObject in the scene; it is recommended this be the object representing the base of the turret, but the script will work for any object.
- Assign the relevant game objects in the Inspector. A typical turret configuration uses the barrel as the pitch segment and the swivel mount as the yaw segment, but other configurations are possible.
- Set the pitch and yaw limits as desired. Values greater than 360, or less than or equal to zero, will result in free rotation without limits.
- Set the rotation speed limits as desired.
- Add weapons as desired. The main script does not include any weapon firing functionality, but rather is designed to cooperate with other weapon scripts. In the example scenes, the weapons are empty game objects placed at the ends of the barrels.
- The turret can be aimed by setting the "target" Vector3 variable, either manually in the inspector or (more usefully) via the public "Target(Vector3)" method in the script. In the example scenes, the targeting method is called on every frame by the "TurretDemo" and "Gun" scripts, but it need not be called every frame and can instead be called during Physics or UI updates.

Notes:
- The pitch and yaw segments need not both be assigned; for a turret that only swivels horizontally, for example, the pitch segment can be left out.
- The pitch and yaw segments must not be the same object, as this leads to errors. Aiming a single-component turret should be a trivial task thanks to the Quaternion.LookRotation() and Quaternion.RotateTowards() methods built into Unity.
- For turrets with multiple barrels that rotate individually, as commonly seen on naval battleships, use multiple turret scripts: one for the base, with only the yaw segment set; and one for each barrel, with only the pitch segment set.
- This package does not extrapolate target motion or "lead targets;" this functionality needs to be added by a custom turret AI script (not included) that assigns target positions based on the expected positions of target objects.

For further information and to submit bug reports, contact the developer via my publisher page on the Unity Asset Store.