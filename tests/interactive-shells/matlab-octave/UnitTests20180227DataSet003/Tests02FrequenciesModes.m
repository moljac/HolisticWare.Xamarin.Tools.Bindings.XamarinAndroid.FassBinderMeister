
# octave - cannot calculate frequencies
# matlab - tabulate
# tabulate([ 1, 2, 2, 3, 3, 4, 5, 6 ])

# pkg install image-1.0.0.tar.gz
# pkg list
# pkg uninstall image

# https://octave.sourceforge.io/statistics/index.html
# https://octave.sourceforge.io/statistics/overview.html

# pkg install ~/Downloads/io-2.4.10.tar.gz
# pkg install ~/Downloads/statistics-1.3.0.tar.gz 

pkg load statistics

#source(Tests00Data)
run("Tests00Data.m")
Tests00Data

frequencies = tabulate(data01);
frequencies 
mode = mode(data01);
mode



