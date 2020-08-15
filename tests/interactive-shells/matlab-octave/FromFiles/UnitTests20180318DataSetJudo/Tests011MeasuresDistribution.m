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



disp ("==================================================================================")
# Arrange
tic ();
# Act
result_iqr = iqr(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_iqr = iqr(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_iqr               = "), disp(result_iqr)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_iqr == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_std = std(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_std = std(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_std               = "), disp(result_std)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_std == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_var = var(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_var = var(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_var               = "), disp(result_var)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_var == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_skewness = skewness(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_bml);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_skewness = skewness(data_ont, 0);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_ouz, 0);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_neb, 0);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_skl, 0);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_trb, 0);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_cuc, 0);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_sdm, 0);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_skewness = skewness(data_bml, 0);
elapsed_time = toc ();
# Assert
disp ("data_bml ")
disp ("result_skewness               = "), disp(result_skewness)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_skewness == 3.8)
disp ("==================================================================================")


disp ("==================================================================================")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_ont);
elapsed_time = toc ();
# Assert
disp ("data_ont ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_ouz);
elapsed_time = toc ();
# Assert
disp ("data_ouz ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_neb);
elapsed_time = toc ();
# Assert
disp ("data_neb ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_skl);
elapsed_time = toc ();
# Assert
disp ("data_skl ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_trb);
elapsed_time = toc ();
# Assert
disp ("data_trb ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_cuc);
elapsed_time = toc ();
# Assert
disp ("data_cuc ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("..............................................................")
# Arrange
tic ();
# Act
result_kurtosis = kurtosis(data_sdm);
elapsed_time = toc ();
# Assert
disp ("data_sdm ")
disp ("result_kurtosis               = "), disp(result_kurtosis)
disp ("              time [\u00B5s] = "), disp(elapsed_time * 1000000)
#assert(result_kurtosis == 3.8)
disp ("==================================================================================")
