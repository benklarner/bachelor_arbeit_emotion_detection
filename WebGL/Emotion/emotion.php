<?php

    $text1 = $_POST["EmotionDataString"];

echo $text1;

	if ($text1 != "")
	{
		echo("Message successfully sent!");
		echo("Field 1:" . $text1);
        echo($text1);
		$file = fopen("emotionData.csv", "a")  or die("Unable to open file!");
		fputcsv($file, explode(";", $text1), ";");
		fclose($file);
	} else
	{
		echo("Message delivery failed...");
	}
?>