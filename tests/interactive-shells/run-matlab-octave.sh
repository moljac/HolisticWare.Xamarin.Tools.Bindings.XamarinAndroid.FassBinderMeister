#!/bin/bash

export EXECUTABLE=octave

$EXECUTABLE \
    ./matlab-octave/01-DarkVaderTests/Tests20180119Dataset01/Tests00Data.m

$EXECUTABLE \
    ./matlab-octave/01-DarkVaderTests/Tests20180119Dataset01/Tests011MeasuresCentralTendencies.m 

$EXECUTABLE \
    ./matlab-octave/FromFiles/UnitTests20180318DataSetBasketball/Tests00Data.m 
