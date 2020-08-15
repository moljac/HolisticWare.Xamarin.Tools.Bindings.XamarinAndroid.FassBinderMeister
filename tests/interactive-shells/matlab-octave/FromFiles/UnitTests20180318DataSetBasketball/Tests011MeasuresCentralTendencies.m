
if ~(exist("data", "var") == 1)
    # https://octave.org/doc/v4.4.1/Including-File-Content.html
    # <include>Tests00Data.m</include>
    # addpath("./interactive-shells/matlab-octave/01-DarkVaderTests/Tests20180119Dataset01/");
    # source ("Tests00Data.m", "caller")
    # run("./Tests00Data.m")
    # Tests00Data
    file_path = fileparts(mfilename('fullpath'));
    file_path
    addpath(file_path);
    run("Tests00Data.m");
endif


disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_2pts_success, "a");
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_2pts_fail, "a");
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_3pts_success, "a");
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_3pts_fail, "a");
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_free_throw_success, "a");
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_free_throw_fail, "a");
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_jumps_offensive, "a");
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_jumps_defensive, "a");
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_jumps_defensive, "a");
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_assistence, "a");
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_personal_faults, "a");
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_balls_lost, "a");
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_balls_stolen, "a");
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_blocks, "a");
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")



disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_geometric = mean(data_2pts_success, "g");
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_2pts_fail, "g");
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_3pts_success, "g");
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_3pts_fail, "g");
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_free_throw_success, "g");
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_free_throw_fail, "g");
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_jumps_offensive, "g");
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_jumps_defensive, "g");
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_jumps_defensive, "g");
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_assistence, "g");
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_personal_faults, "g");
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_balls_lost, "g");
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_balls_stolen, "g");
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_blocks, "g");
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("==================================================================================")



disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_2pts_success, "h");
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_2pts_fail, "h");
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_3pts_success, "h");
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_3pts_fail, "h");
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_free_throw_success, "h");
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_free_throw_fail, "h");
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_jumps_offensive, "h");
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_jumps_defensive, "h");
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_jumps_defensive, "h");
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_assistence, "h");
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_personal_faults, "h");
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_balls_lost, "h");
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_balls_stolen, "h");
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_blocks, "h");
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_squared = meansq(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_median = median(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_mode = mode(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_range = range(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("==================================================================================")

