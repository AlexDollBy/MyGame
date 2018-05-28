<?php
    $servername = "localhost";
	$username = "bydol578_alexd";
	$password = "445566778899";
	$dbName = "bydol578_alexd";
	
	//Make Connection
	$conn = new mysqli($servername,$username,$password,$dbName);
	// Check connection
	if (!$conn){
		die("Connection FAILED".mysqli_connect_error());
	}

	$sql = "SELECT ID,Login,Password,Score FROM players";
	$result = mysqli_query($conn,$sql);
	
	if (mysqli_num_rows($result)>0)
	{
		while ($row = mysqli_fetch_assoc($result)){
		echo "ID:".$row['ID'] . "|Login:".$row['Login']."|Password:" . $row ['Password']."|Score:" . $row ['Score'].";";
		}
	}

		
?>