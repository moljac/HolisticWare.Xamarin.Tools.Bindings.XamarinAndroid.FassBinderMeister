# pip install statistics

import os
import sys

#-------------------------------------------------------------------------------------------
# https://docs.python.org/3/library/csv.html
import csv
csv_filename = '../../../../../externals/Core.Math.Samples/data/HolisticWare.Core.Sample.Data/Xtras-SampleData/Judo.comma.csv';
with open(csv_filename) as csvfile:
    csv_reader = csv.reader(csvfile, delimiter=',')
    line_count = 0
    for row in csv_reader:
        if line_count == 0:
            print(f'Column names are {", ".join(row)}')
            print(f'{"      ".join(row)}')
            line_count += 1
        else:
            print(row)
            line_count += 1
    print(f'Processed {line_count} lines.')

print("======================================================================================")
# https://realpython.com/python-csv/
import pandas
data_pandas = pandas.read_csv(csv_filename)
print(data_pandas)
#-------------------------------------------------------------------------------------------

series = data_pandas['ONT']  # as a Series
numpy_array = data_pandas['ONT'].values  # as a numpy array

print(series)
print(numpy_array)

# data = \
# [ \
#     1, 2, 2, 3, 3, 3, 3, 4, 4, 5 \
# ]
# 
# # Add the directory containing your module to the Python path (wants absolute paths)
# scriptpath2 = "./Tests011MeasuresDistribution.py"
# sys.path.append(os.path.abspath(scriptpath2))
# import Tests011MeasuresDistribution
# 
# # Add the directory containing your module to the Python path (wants absolute paths)
# scriptpath1 = "./Tests011MeasuresCentralTendencies.py"
# sys.path.append(os.path.abspath(scriptpath1))
# import Tests011MeasuresCentralTendencies

