# pip install statistics

import os
import sys

data = \
[ \
            160, 135, 175, 170, 155, 170, 165, 150, 155, 195, \
            175, 150, 180, 210, 180, 205, 180, 160, 170, 185, \
            160, 195, 190, 205, 160, 185, 180, 205, 195, 180, \
            160, 170, 155, 150, 195, 175, 175, 190, 185, 180, \
            180, 190, 195, 175, 175, 175, 175, 150, 165, 180, \
            165, 195, 200, 190, 190, 165, 170, 205, 200, 180  \
]

# Add the directory containing your module to the Python path (wants absolute paths)
scriptpath2 = "./Tests011MeasuresDistribution.py"
sys.path.append(os.path.abspath(scriptpath2))
import Tests011MeasuresDistribution

# Add the directory containing your module to the Python path (wants absolute paths)
scriptpath1 = "./Tests011MeasuresCentralTendencies.py"
sys.path.append(os.path.abspath(scriptpath1))
import Tests011MeasuresCentralTendencies
