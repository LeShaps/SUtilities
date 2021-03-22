#!bin/sh
set -e
cd SUtilitiesTests/TestResults
cd $(ls)
cp coverage.cobertura.xml ../../../coverage.xml
cd ../../../