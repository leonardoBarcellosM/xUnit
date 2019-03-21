@pushd %~dp0

cd ./SpecFlowPlusRunner/net45

@set profile=%1
@if "%profile%" == "" set profile=Default

SpecRun.exe run "%profile%.srprofile" --baseFolder "../.." --log "specrun.log" %2 %3 %4 %5

:end

@popd
