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
	$GameUser = $_GET["usernamePost"];
  $GamePassword = $_GET["passwordPost"];   
  $GameScore = $_GET["scorePost"];   
 $sql = "UPDATE `players` SET `Score`=".$GameScore." WHERE `Login`='".$GameUser."' AND `Password`='".$GamePassword."'";  
 
// 	$sql = "INSERT INTO players (Login,Password) VALUES ('".$GameUser."','".$GamePassword."')";  
  echo $sql;
	$result = mysqli_query($conn,$sql);    
  echo $result;
	if(!$result) echo "Error";
		
?>