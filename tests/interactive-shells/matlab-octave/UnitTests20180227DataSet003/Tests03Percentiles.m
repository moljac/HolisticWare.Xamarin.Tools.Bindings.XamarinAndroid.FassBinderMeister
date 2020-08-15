
#source(Tests00Data)
run("Tests00Data.m")
Tests00Data

quantile_0_1_min_max = quantile (data01, [0, 1]);   # Return minimum, maximum of distribution
quantile_0_1_min_max
quantile_25_50_75 = quantile (data01, [0.25 0.5 0.75]); # Return quartiles of distribution
quantile_25_50_75 


percentile  = prctile (data01);
percentile

