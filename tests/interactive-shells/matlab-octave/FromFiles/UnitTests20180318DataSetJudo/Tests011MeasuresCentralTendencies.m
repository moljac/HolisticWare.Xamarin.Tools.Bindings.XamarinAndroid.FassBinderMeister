
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
mean_arithmetic = mean(data_ont, "a");
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_ouz, "a");
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_neb, "a");
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_skl, "a");
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_trb, "a");
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_cuc, "a");
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_sdm, "a");
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_arithmetic = mean(data_bml, "a");
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("mean_arithmetic               = "), disp(mean_arithmetic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_arithmetic == 3.8)
disp ("==================================================================================")



disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_geometric = mean(data_ont, "g");
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_ouz, "g");
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_neb, "g");
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_skl, "g");
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_trb, "g");
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_cuc, "g");
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_sdm, "g");
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_geometric = mean(data_bml, "g");
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("mean_geometric               = "), disp(mean_geometric)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_geometric == 3.8)
disp ("==================================================================================")



disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_ont, "h");
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_ouz, "h");
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_neb, "h");
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_skl, "h");
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_trb, "h");
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_cuc, "h");
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_sdm, "h");
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_harmonic = mean(data_bml, "h");
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("mean_harmonic               = "), disp(mean_harmonic)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_harmonic == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
mean_squared = meansq(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
mean_squared = meansq(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("mean_squared               = "), disp(mean_squared)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(mean_squared == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_median = median(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_median = median(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_median               = "), disp(result_median)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_median == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_mode = mode(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_mode = mode(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_mode               = "), disp(result_mode)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_mode == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_range = range(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_range = range(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_range               = "), disp(result_range)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_range == 3.8)

disp ("==================================================================================")

