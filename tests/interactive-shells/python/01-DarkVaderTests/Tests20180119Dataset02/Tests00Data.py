# pip install statistics

import os
import sys

data = \
[ \
            25.4, 14.7, 16.4, 15.3, 17.4, 15.0, 15.0, 19.4, 17.5, 14.7, \
            18.0, 15.2, 16.0, 13.7, 18.2, 15.9, 14.7, 13.3, 15.1, 17.6, \
            16.1, 12.9, 12.2, 12.7, 16.2, 13.5, 11.8, 11.7, 13.4, 17.0, \
            17.1, 13.8, 15.5, 19.3, 16.2, 16.9, 12.1, 16.8, 11.6, 13.0, \
            12.9, 10.5, 11.3, 14.3, 19.5, 18.6, 18.6, 22.9, 19.8, 13.4, \
            18.2, 14.5, 24.0, 16.5, 16.4, 28.9, 13.5, 13.6, 11.9, 18.2  \
]

# Add the directory containing your module to the Python path (wants absolute paths)
scriptpath2 = "./Tests011MeasuresDistribution.py"
sys.path.append(os.path.abspath(scriptpath2))
import Tests011MeasuresDistribution

# Add the directory containing your module to the Python path (wants absolute paths)
scriptpath1 = "./Tests011MeasuresCentralTendencies.py"
sys.path.append(os.path.abspath(scriptpath1))
import Tests011MeasuresCentralTendencies
