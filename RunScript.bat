ECHO off
sqlcmd -s localhost -e -i Script.sql
ECHO .
ECHO if no errors appear DB was created
PAUSE