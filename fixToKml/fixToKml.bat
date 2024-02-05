DEL fix*.kml

DEL fixToKml.txt

mysql.exe --login-path=batch --table < fixToKml.sql

fixToKml.exe fixToKml.txt

DEL fixToKml.txt

REM SET GDAL_DATA=C:\\Program Files\\QGIS 3.22.1\\apps\\gdal-dev\\data
REM SET GDAL_DRIVER_PATH=C:\\Program Files\\QGIS 3.22.1\\bin\\gdalplugins
REM SET OSGEO4W_ROOT=C:\\Program Files\\QGIS 3.22.1
REM SET PATH=%OSGEO4W_ROOT%\\bin;%PATH%
REM SET PYTHONHOME=%OSGEO4W_ROOT%\\apps\\Python37
REM SET PYTHONPATH=%OSGEO4W_ROOT%\\apps\\Python37

REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\cnf.shp" "cnf.kml" cnf
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\coordnfix.shp" "coordnfix.kml" coordnfix
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\milreppt.shp" "milreppt.kml" milreppt
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\milwaypoint.shp" "milwaypoint.kml" milwaypoint
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\nrswaypoint.shp" "nrswaypoint.kml" nrswaypoint
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\radar.shp" "radar.kml" radar
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\reppt.shp" "reppt.kml" reppt
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\vfrwp.shp" "vfrwp.kml" vfrwp
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\waypoint.shp" "waypoint.kml" waypoint
