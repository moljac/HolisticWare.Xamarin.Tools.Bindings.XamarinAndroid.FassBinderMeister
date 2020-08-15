
#-------------------------------------------------------------------------------------------
# path setup
this_script_path = fileparts(mfilename('fullpath'));
addpath(this_script_path);
csv_filename = '../../../../../externals/Core.Math.Samples/data/HolisticWare.Core.Sample.Data/Xtras-SampleData/Judo.comma.csv';
filename = [this_script_path,'/',csv_filename]
#-------------------------------------------------------------------------------------------

filecontent = fileread(filename);
filecontent
data = csvread(filename);
data
# data = dlmread(filename)(:,1:8);
# data
# data = importread(filename).data(:,1:8);

# ONT,OUZ,NEB,SKL,TRB,CUC,SDM,BML

data_ont = data(2:end, 1); 
data_ouz = data(2:end, 2); 
data_neb = data(2:end, 3); 
data_skl = data(2:end, 4); 
data_trb = data(2:end, 5); 
data_cuc = data(2:end, 6); 
data_sdm = data(2:end, 7); 
data_bml = data(2:end, 8); 

run("Tests011MeasuresCentralTendencies.m");
#run("Tests011MeasuresDistribution.m");
 
