
#source(Tests00Data)
run("Tests00Data.m")
Tests00Data

mean_arithmetic = mean(data01, "a");
mean_arithmetic
mean_geometric = mean(data01, "g");
mean_geometric
mean_harmonic = mean(data01, "h");
mean_harmonic
mean_squared = meansq(data01);
mean_squared

median = median(data01);
median


