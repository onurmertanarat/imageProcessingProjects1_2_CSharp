<h1>Image Processing - Color Detection</h1>

<h2>About the Project</h2>

<p>
    This project aims to detect and track specific colors in a live video feed captured from a webcam. It utilizes
    C# for color detection algorithms and Arduino for hardware control, such as moving robotic arms or controlling
    LEDs, based on the detected colors.
</p>

<h2>Overview</h2>

<p>
    The project consists of two main components:
</p>

<ol>
    <li>
        <strong>C# Application:</strong> The C# application runs on a computer with a connected webcam. It captures
        live video frames, processes them to detect specific colors, and displays the results in real-time.
    </li>
    <li>
        <strong>Arduino Integration:</strong> The Arduino part of the project communicates with the C# application
        and controls hardware components, such as motors or LEDs, based on the color detection results obtained
        from the C# application.
    </li>
</ol>

<h2>Implementation Details</h2>

<h3>C# Application (Form1.cs)</h3>

<p>
    The C# application utilizes the AForge.NET Framework for image processing tasks, such as color filtering and
    blob detection. Here's a brief overview of the key functionalities implemented in the Form1.cs file:
</p>

<ul>
    <li><strong>Initializing Webcam:</strong> The application detects and initializes the connected webcam using the
        AForge.Video.DirectShow library.</li>
    <li><strong>Color Detection Modes:</strong> Users can select different color detection modes, such as single-color
        detection or multi-color detection.</li>
    <li><strong>Parameter Adjustment:</strong> The application allows users to adjust parameters like color thresholds
        using trackbars to fine-tune the color detection process.</li>
    <li><strong>Live Video Feed:</strong> The captured live video feed is displayed in real-time, with detected color
        regions highlighted.</li>
    <li><strong>Serial Communication:</strong> Serial communication is established with the Arduino board to send
        commands based on color detection results.</li>
</ul>

<h3>Arduino Integration</h3>

<p>
    The Arduino part of the project receives commands from the C# application via serial communication and controls
    the connected hardware accordingly. For example, if a specific color is detected, the Arduino board can trigger
    actions like moving a robotic arm or lighting up LEDs of corresponding colors.
</p>

<h2>Setup and Configuration</h2>

<ol>
    <li>Install the necessary dependencies:</li>
    <ul>
        <li><strong>AForge.NET Framework:</strong> Download and install AForge.NET Framework from the official website:
            <a href="https://www.aforgenet.com/framework/">https://www.aforgenet.com/framework/</a></li>
        <li><strong>Arduino IDE:</strong> Download and install Arduino IDE from the official website:
            <a href="https://www.arduino.cc/en/software">https://www.arduino.cc/en/software</a></li>
    </ul>
    <li>Connect your webcam to the computer.</li>
    <li>Connect the Arduino board to the computer.</li>
    <li>Open the C# project in Visual Studio or any compatible IDE.</li>
    <li>Compile and run the C# application.</li>
    <li>Upload the Arduino sketch to the Arduino board using the Arduino IDE.</li>
    <li>Adjust parameters and select color detection modes as needed.</li>
    <li>Observe the live video feed and hardware actions based on color detection results.</li>
</ol>

<h2>Contributing</h2>

<p>
    Contributions to the project are welcome! If you'd like to contribute, please fork the repository, make your changes,
    and submit a pull request.
</p>

<h2>License</h2>

<p>
    This project is licensed under the MIT License. See the <a href="LICENSE">LICENSE</a> file for details.
</p>
