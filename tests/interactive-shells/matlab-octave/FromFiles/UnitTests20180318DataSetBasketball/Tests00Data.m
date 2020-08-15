
#-------------------------------------------------------------------------------------------
# path setup
this_script_path = fileparts(mfilename('fullpath'));
addpath(this_script_path);
csv_filename = '../../../../../externals/Core.Math.Samples/data/HolisticWare.Core.Sample.Data/Xtras-SampleData/Basketball.comma.csv';
filename = [this_script_path,'/',csv_filename]
#-------------------------------------------------------------------------------------------

filecontent = fileread(filename);
filecontent
data = csvread(filename);
data
# data = dlmread(filename)(:,1:8);
# data
# data = importread(filename).data(:,1:8);

# SUT_2_US,SUT_2_NE,SUT_3_US,SUT_3_NE,SL_BA_US,SL_BA_NE,SKOK_NAP,SKOK_OBR,ASISTENC,OSOB_GRE,IZG_LOPT,UKR_LOPT,BLOKADE,K1,K2

data_2pts_success = data(2:end, 1); 
data_2pts_fail = data(2:end, 2); 
data_3pts_success = data(2:end, 3); 
data_3pts_fail = data(2:end, 4); 
data_free_throw_success = data(2:end, 5); 
data_free_throw_fail = data(2:end, 6); 
data_jumps_offensive = data(2:end, 7); 
data_jumps_defensive = data(2:end, 8); 
data_assistence = data(2:end, 9); 
data_personal_faults = data(2:end, 10); 
data_balls_lost = data(2:end, 11); 
data_balls_stolen = data(2:end, 12); 
data_blocks = data(2:end, 13); 

run("Tests011MeasuresCentralTendencies.m");
run("Tests011MeasuresDistribution.m");
 
