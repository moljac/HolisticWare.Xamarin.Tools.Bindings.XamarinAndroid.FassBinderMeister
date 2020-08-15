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



disp ("==================================================================================")
# Arrange
tic ();
# Act
result_iqr = iqr(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_std = std(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_var = var(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_skewness = skewness(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_skewness = skewness(data_2pts_success, 0);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_2pts_fail, 0);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_3pts_success, 0);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_3pts_fail, 0);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_free_throw_success, 0);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_free_throw_fail, 0);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_jumps_offensive, 0);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_jumps_defensive, 0);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_jumps_defensive, 0);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_assistence, 0);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_personal_faults, 0);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_balls_lost, 0);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_balls_stolen, 0);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_blocks, 0);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_2pts_success);
elapsed_time = toc ();
# Assert
disp ("data_2pts_success ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_2pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_2pts_fail ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_3pts_success);
elapsed_time = toc ();
# Assert
disp ("data_3pts_success ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_3pts_fail);
elapsed_time = toc ();
# Assert
disp ("data_3pts_fail ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_free_throw_success);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_success ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_free_throw_fail);
elapsed_time = toc ();
# Assert
disp ("data_free_throw_fail ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_jumps_offensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_offensive ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_jumps_defensive);
elapsed_time = toc ();
# Assert
disp ("data_jumps_defensive ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_assistence);
elapsed_time = toc ();
# Assert
disp ("data_assistence ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_personal_faults);
elapsed_time = toc ();
# Assert
disp ("data_personal_faults ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_balls_lost);
elapsed_time = toc ();
# Assert
disp ("data_balls_lost ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_balls_stolen);
elapsed_time = toc ();
# Assert
disp ("data_balls_stolen ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_blocks);
elapsed_time = toc ();
# Assert
disp ("data_blocks ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("==================================================================================")
