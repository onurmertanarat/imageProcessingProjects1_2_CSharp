# Real-Time Object Tracking & Hardware Control (University Project)

This project is a desktop application developed in C# and Windows Forms. It was created as a final project for the "Image Processing" course during my Mechatronics Engineering studies at Karabük University.

**Please Note:** This project is preserved in its **original state** from my university years. It serves as an authentic snapshot of my skills and understanding at the beginning of my software development journey, showcasing an early passion for integrating software with the physical world.

<p>
  <img src="https://github.com/onurmertanarat/imageProcessingProjects1_2_CSharp/blob/master/assets/project-asv-gif.gif" alt="Application Demo GIF" width="900">
</p>

---

## Project Overview

The application captures live video from a webcam, performs real-time color-based object tracking, and sends commands to an external hardware device (e.g., an Arduino) via the serial port based on the detected object's on-screen position.

The main goal was to create a "pick and place" type of logic where a physical system could react to visual input from a camera.

### Core Features

* **Real-Time Video Processing:** Captures and processes video frames live using the powerful AForge.NET framework.
* **Color-Based Object Tracking:** Uses `EuclideanColorFiltering` to isolate an object of a specific color (adjustable via UI trackbars) and `BlobCounter` to identify its position and size.
* **Serial Port Communication:** Divides the screen into a 3x3 grid and sends a corresponding command (e.g., "1", "2", ... "9") over the selected serial port based on which grid segment the tracked object is in.
* **Desktop GUI:** A simple Windows Forms interface allows the user to select the camera, configure serial port settings, and adjust the target color in real-time.

---

## Technology Stack

* **Language:** C#
* **Framework:** .NET Framework (Windows Forms)
* **Core Library:** AForge.NET (for computer vision tasks)
* **Communication:** `System.IO.Ports` (for Serial Port communication)

---

## Retrospective: What I Would Do Differently Today

As a record of my learning process, I am keeping the original code unchanged. However, with my current knowledge and experience, I would make several key improvements:

* **Refactor for the DRY Principle:** I would refactor the heavily duplicated image processing logic in the different modes (`case 2`, `case 3`, etc.) into a single, reusable function to make the code cleaner and easier to maintain.
* **Eliminate "Magic Numbers":** I would replace hardcoded numbers like `200` (grid width) or `13` (blob size) with named constants for better readability and easier configuration.
* **Improve Logic with Functions:** The long `if/else if` chain for grid position detection would be replaced by an elegant mathematical function that calculates the grid number directly from X/Y coordinates.
* **Modern Architecture:** I would separate the UI logic from the business logic (image processing and serial communication) using a modern design pattern like MVVM (Model-View-ViewModel) to improve testability and scalability.

---

## Setup

This project was developed using Visual Studio and the .NET Framework. To run it, the AForge.NET framework libraries are required as a dependency.

### **Important: Camera Configuration**

For the application to work, you may need to manually select the camera source in the code. **By default, the project is hardcoded to use a secondary/external camera.**

1.  Open the `Form1.cs` file.
2.  Navigate to the `formASV_Load` method.
3.  Find the line: `comboBox1.SelectedIndex = 1;`
4.  To use your computer's primary/built-in camera, change this line to: `comboBox1.SelectedIndex = 0;`

### Note on Virtual Cameras (OBS)
This application may have issues with some modern physical webcams due to pixel format mismatches. It has been tested and works reliably with a virtual camera like **OBS Virtual Camera**. The code added to the `button1_Click` event helps negotiate a compatible video resolution, which is often necessary for virtual cameras to work.

---

## Contact

Onur Mert Anarat

[linkedin.com/in/onurmertanarat](https://www.linkedin.com/in/onurmertanarat)
