# **Unchosen: Forsaken (2021)**

*First Published Game • VR Horror • Released July 2021 on Steam*

*Steam Page:* https://store.steampowered.com/app/1608010/Unchosen_Forsaken

*Availability:* Paid (Steam key available upon request)

# **⭐ Project Overview**

Unchosen: Forsaken is a first-person VR horror experience developed entirely solo over the course of 2020–2021. Inspired by my night-shift job working alone in a call center overnight, the game focuses on fear, tension, and psychological pressure rather than combat. Players navigate four distinct levels—an office complex, a sewer system, city streets, and a large-scale boss arena—while avoiding and outsmarting a variety of hostile entities.

*This was my first published game, launching on Steam in July 2021. It pushed my abilities across VR interaction design, AI behavior systems, animation, sound design, and performance-conscious level construction.*

# **🎮 Gameplay Summary**

## Unchosen: Forsaken emphasizes survival through intelligence, not combat. The player cannot harm the creatures; instead, they must:

-Use light, sound, and movement to manipulate enemies

-Learn which entities are drawn to light and which are repelled

-Identify which creatures must be watched and which must be avoided entirely

-Navigate dark environments using flashlights, lanterns, and a VR backpack system

-Avoid traps and environmental hazards

-Solve spatial challenges and find items placed in randomized positions

*Each enemy type uses its own specialized behavior, creating a layered, unpredictable horror experience.*

# **🧩 Key Features**

-Fully immersive VR interaction system

-Four distinct levels with unique mechanics and atmosphere

-Multiple enemy AI types using different sensory behaviors (light, sound, vision)

-Randomized item spawns across fixed maps

-20 level layouts per floor with baked lighting and pathfinding

-Full set of custom audio and ambience produced in Audacity

-VR backpack inventory system

-Hand-crafted animations using the Legacy Animation system

-Solo-developed but integrated with third-party VR and 3D asset packs

-Boss encounter with a large-scale entity

# **🏗️ Architecture Overview**

**Unchosen: Forsaken represents a major step forward in my programming maturity. Compared to my 2020 project, this game introduced clearer boundaries between systems, fewer duplicated methods, and more modular behaviors.**

## Key technical and architectural highlights:

-Enemy AI built around a generic Enum-driven State Machine

-Reduced Update usage across all systems

-Serialized field-driven architecture for rapid tuning

-Minimal per-frame operations to maintain performance in VR

-Efficient VR interaction logic with clear input separation

-Pre-baked lighting and fixed navigation meshes for stable performance

-Level variety handled through prebuilt map variants instead of procedural generation

-No more repeated scripts; logic was centralized into purpose-built systems

*There is still a large “god controller” script and some early naming conventions, but architecture was significantly improved from prior projects.*

# **🗂️ Key Scripts to Review**

## *Core*

*Player.cs*

## *Systems*

*Movement.cs*

*SpawnController.cs*

*HostileSpawner.cs*

*ItemSpawner.cs*

*introScript.cs*

*MapControllerS.cs*

*Flashlight.cs*

*OutsideHostileSpawner.cs*

*Launtern.cs*

## *AI*

*Hostile2.cs*

*Ghost.cs*

## *Utilities*

*HandPresence.cs*

*Flicker.cs*

*Holder.cs*

*Holdster.cs*

*PointTest.cs*

*LightRays.cs*

# **🧪 Development Notes**

## Performance was a priority due to VR constraints:

-Nearly all level lighting was baked

-NavMeshes pre-generated for each floor variant

-Minimal active Update loops

-Most systems used event-driven or serialized behavior

-VR interactions optimized for low-latency responsiveness

-Despite using basic lighting and large levels, the game maintained solid performance across supported VR devices.

## *VR Interaction*

-Smooth object picking, holding, storing, and switching

-Physics-based flashlight behavior

-Lanterns that provide passive light but draw certain enemies

-Backpack inventory system inspired by real VR workflows

## *Audio Design*

-All audio—sound effects, ambience, music—was created manually:

-Sewer areas use extended reverb

-City streets have long-range echo effects

-Office space uses muted, claustrophobic ambience

*No reliance on Unity’s audio zones; instead, level-specific audio variations were pre-generated*

# **🚧 Why This Project Matters**

## Unchosen: Forsaken was my first published title and a major milestone in my development career. It demonstrates:

-My ability to complete and ship a full VR game

-My versatility across AI, sound design, VR interaction, and level creation

-My early growth into better system separation and architecture

-My capacity to integrate and modify third-party assets into a cohesive experience

-My willingness to solve difficult technical problems despite limited prior experience

-My ability to adapt to VR-specific constraints such as latency, performance, and immersion

*This project marked the beginning of my transition from experimentation to structured, production-minded programming.*

# **📚 Lessons Learned**

-How to design scalable AI behaviors without complex frameworks

-How to optimize VR gameplay loops for performance and comfort

-Importance of avoiding “god scripts” and improving naming conventions

-First experience integrating Asset Store toolkits professionally

-Importance of workflow tools like Blender and proper mesh construction

-Audio design fundamentals and how ambience changes gameplay

-How level variety can be achieved without runtime generation

# **🛠️ Tech Stack**

Unity 2020.x

C#

SteamVR or similar VR toolkit

Legacy Animation System

Custom Audio (created in Audacity)

Unity Asset Store VR frameworks and environment kits
