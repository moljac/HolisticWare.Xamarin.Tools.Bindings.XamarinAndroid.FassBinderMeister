
data = ...
[ 
    2, 4, 3, 5, 6, 7, 4, 4, 2, 1
];
data

file_path = fileparts(mfilename('fullpath'));
file_path
addpath(file_path);
which("Tests011MeasuresCentralTendencies");

run("Tests011MeasuresCentralTendencies.m");
run("Tests011MeasuresDistribution.m");

