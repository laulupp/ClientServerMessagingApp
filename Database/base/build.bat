@echo off
echo ---------------------------------
echo Building scs_db_base:latest
echo ---------------------------------
call docker build -t scs_db_base:latest .
pause > nul
exit