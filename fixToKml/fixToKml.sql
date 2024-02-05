USE aviation;

SELECT *
	INTO OUTFILE 'C:\\Users\\junk_\\Documents\\qgisBatch\\fixToKml.txt' FIELDS TERMINATED BY '~' LINES TERMINATED BY '\r\n'
	FROM fixLocation;
