# pip install statistics

import os
import sys

data = [ 2, 4, 3, 5, 6, 7, 4, 4, 2, 1 ]

scriptpath = "./Tests01MeanAverageMedian.py"

# Add the directory containing your module to the Python path (wants absolute paths)
sys.path.append(os.path.abspath(scriptpath))

# Do the import
import Tests01MeanAverageMedian

