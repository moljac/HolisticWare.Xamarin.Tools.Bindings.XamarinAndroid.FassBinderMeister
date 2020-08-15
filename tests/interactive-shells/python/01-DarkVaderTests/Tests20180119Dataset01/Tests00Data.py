# pip install statistics

import os
import sys

data = \
[ \
    1, 2, 2, 3, 3, 3, 3, 4, 4, 5 \
]

# Add the directory containing your module to the Python path (wants absolute paths)
scriptpath2 = "./Tests011MeasuresDistribution.py"
sys.path.append(os.path.abspath(scriptpath2))
import Tests011MeasuresDistribution

# Add the directory containing your module to the Python path (wants absolute paths)
scriptpath1 = "./Tests011MeasuresCentralTendencies.py"
sys.path.append(os.path.abspath(scriptpath1))
import Tests011MeasuresCentralTendencies

