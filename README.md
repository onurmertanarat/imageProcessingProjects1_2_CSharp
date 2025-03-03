# Image Processing - Color Detection

## About the Project
This project detects and tracks specific colors in a live video feed using a webcam. It leverages C# for image processing and Arduino for hardware control, enabling actions like robotic arm movement or LED activation based on detected colors.

## Overview
The project consists of two main components:

- **C# Application**: Captures live video, processes frames for color detection, and displays results in real-time.
- **Arduino Integration**: Receives commands from the C# application via serial communication to control hardware components.

## Implementation Details
### C# Application (Form1.cs)
The C# application utilizes the **AForge.NET Framework** for image processing, including color filtering and blob detection. Key features:

- **Webcam Initialization**: Detects and initializes the connected webcam using `AForge.Video.DirectShow`.
- **Color Detection Modes**: Supports single-color and multi-color detection.
- **Parameter Adjustment**: Allows fine-tuning of color thresholds using trackbars.
- **Live Video Feed**: Displays real-time video with highlighted detected color regions.
- **Serial Communication**: Sends commands to the Arduino based on detected colors.

### Arduino Integration
The Arduino component:

- Receives serial commands from the C# application.
- Controls motors, LEDs, or other hardware components based on detected colors.

## Setup and Configuration
1. Install dependencies:
   - [AForge.NET Framework](https://www.aforgenet.com/framework/)
   - [Arduino IDE](https://www.arduino.cc/en/software)
2. Connect your **webcam** and **Arduino board** to the computer.
3. Open the C# project in **Visual Studio**.
4. Compile and run the C# application.
5. Upload the Arduino sketch via the **Arduino IDE**.
6. Adjust parameters and select color detection modes.
7. Monitor the live feed and hardware responses.

## Contributing
Contributions are welcome! Fork the repository, make changes, and submit a pull request.

## License
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.
