# Platform Watcher

[![openupm](https://img.shields.io/npm/v/com.segur.platform-watcher?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.segur.platform-watcher/)
[![openupm](https://img.shields.io/badge/dynamic/json?color=brightgreen&label=downloads&query=%24.downloads&suffix=%2Fmonth&url=https%3A%2F%2Fpackage.openupm.com%2Fdownloads%2Fpoint%2Flast-month%2Fcom.segur.platform-watcher)](https://openupm.com/packages/com.segur.platform-watcher/)
![unity version badge](https://img.shields.io/badge/Unity%202019.4%20or%20later-supported-blue)

# What is this tool?

This tool displays an error if the Unity platform is not the specified one.

For example, have you ever been working with several people on a Unity project for WebGL application development, and one of the members of the team did not switch the Platform to WebGL, and you encountered a mysterious build error and spent a lot of time troubleshooting?

With this tool, if you forgot to Switch Platform, the error will be displayed and you will notice it immediately!

Please give it a try!


# Requirements

Unity 2019.4 or later


# Install via OpenUPM command-line interface

```bash
# Install openupm-cli
npm install -g openupm-cli

# Go to your unity project directory
cd YOUR_UNITY_PROJECT_DIR

# Install package:
openupm add com.segur.platform-watcher
```


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


# Setting File

The information about which Platform is selected is stored in the file `PlatformWatcherSetting`.json under the `ProjectSettings` folder.

![setting file](./Documentation/setting_file.png)

If you share this file via Git or other means, you can share the settings even if multiple people are developing a Unity project!
