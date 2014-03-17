# GPS Tracking and Google Integration Test
This project is a proof-of-concept to demonstrate:
 * Collection of GPS coordinates via a Windows app using the Sensor API
 *  Verification and display of tracked route via Google Maps API

## Layers involved and test requirements:

 - GPS Device
 - GPS Windows Driver
 - GPS Sensor Driver
	- This one is free: http://www.turboirc.com/gps7/
	- Requires configuration of COM port number and baud rate, which I found via the GPS reference utility
 - Windows Sensor API
	- requires Windows 7 and higher
	- greatly simplifies development against sensors such as GPS, light sensors, accelerometers

## Considerations for production use:

 - Need to clearly indicate when GPS device is ready.
 - How often should samples be taken?
 - What should be done if coordinates do not change? Continue recording or wait for movement? 

## Usage
 1 - Ensure the requirements listed above are met.
 3 - Compile and run GpsTest.exe to capture some coordinates.  Output is recorded to {exe_dir}\GPS-Output-yyyy-mm-dd hh-mm-ss.csv) on save.
 4 - Set the project GpsTest.WebClient as Startup and run it.
 5 - Browse to and upload the generated output file to view your route!

