#!/bin/bash

# pip install statistics 
# pip install scipy numpy

# pip3 install statistics 
# pip3 install scipy numpy

# $PYTHON \
#     -m pip install --trusted-host pypi.python.org mglearn

export EXECUTABLE=python3

$EXECUTABLE \
    ./python/python-website-data/statistics_samples.py


$EXECUTABLE \
    ./python/01-DarkVaderTests/Tests20180119Dataset01/Tests00Data.py 

$EXECUTABLE \
    ./python/01-DarkVaderTests/Tests20180119Dataset01/Tests011MeasuresCentralTendencies.py


