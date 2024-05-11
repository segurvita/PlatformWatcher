# Platform Watcher

# What is this tool?

This tool displays an error if the Unity platform is not the specified one.

For example, have you ever continued working on a WebGL application without switching the platform to WebGL, only to encounter mysterious build errors and spend a lot of time troubleshooting?

With this tool, you can immediately notice if you forget to switch the platform.

Please give it a try!




# Requirements

Unity 2019.4 or later


# How to use

## 1. Open the Platform Watcher
Navigate to  `Tools > Platform Watcher`.

![menuitem](./Documentation/menuitem.png)

## 2. Access the Platform Watcher Window

The Platform Watcher window will appear.

<img width="600" src="./Documentation/unity2022_unknown.png" />

## 3. Select Your Desired Platform

Click `Unknown` and choose the platform you want.

![unity2022_build_target_group_list](./Documentation/unity2022_build_target_group_list.png)

For example, you can select `Vision OS` as shown below:

<img width="600" src="./Documentation/unity2022_visionos.png" />

## 4. Check for Platform Mismatch

- If the active platform **IS** `Vision OS`, no error message will be displayed.
- If the active platform **IS NOT** `Vision OS`, an error message will appear.

<img width="600" src="./Documentation/error_visionos.png" />


# Multi-Platform Support
You can select multiple platforms.

For example, iOS and Android can be selected as shown below:

<img width="600" src="./Documentation/unity2022_ios_android.png" />

