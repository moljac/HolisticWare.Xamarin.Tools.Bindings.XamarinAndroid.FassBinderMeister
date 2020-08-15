
disp ("==================================================================================")
# Arrange
tic ();
# Act
std = std(data);
elapsed_time = toc ();
# Assert
disp ("iqr                          = "), disp(std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
var = var(data);
elapsed_time = toc ();
# Assert
disp ("var                          = "), disp(var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
s1 = skewness(data, 1);
elapsed_time = toc ();
# Assert
disp ("skewness                     = "), disp(s1)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
k1 = kurtosis(data, 1);
elapsed_time = toc ();
# Assert
disp ("kurtosis                     = "), disp(k1)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
s0 = skewness(data, 0);
elapsed_time = toc ();
# Assert
disp ("skewness w bias              = "), disp(s0)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")
