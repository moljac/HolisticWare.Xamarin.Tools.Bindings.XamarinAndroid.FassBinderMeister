#source(Tests00Data)
run("Tests00Data.m")
Tests00Data

# p-th central moment of the vector x.
#       moment (x) = 1/N SUM_i (x(i) - mean(x))^p

# "c" 
#   Central Moment (default).

# "a" "ac"
#   Absolute Central Moment. The moment about the mean ignoring sign defined as
#       moment (x) = 1/N SUM_i (abs (x(i) - mean(x)))^p

# "r"
# Raw Moment. The moment about zero defined as
#       moment (x) = 1/N SUM_i x(i)^p

# "ar"
# Absolute Raw Moment. The moment about zero ignoring sign defined as
#       moment (x) = 1/N SUM_i ( abs (x(i)) )^p


mmoment_1 = moment(data01, 1);
mmoment_1
mmoment_central_1 = moment(data01, 1, "c");
mmoment_central_1
disp ("----------------------------------------------------------------------------------")
mmoment_2 = moment(data01, 2);
mmoment_2
mmoment_central_2 = moment(data01, 2, "c");
mmoment_central_2
mmoment_central_absolute_2 = moment(data01, 2, "ac");
mmoment_central_absolute_2
mmoment_central_absolute_2 = moment(data01, 2, "a");
mmoment_central_absolute_2
mmoment_raw_2 = moment(data01, 2, "r");
mmoment_raw_2
mmoment_raw_absolute_2 = moment(data01, 2, "ar");
mmoment_raw_absolute_2
disp ("----------------------------------------------------------------------------------")
mmoment_3 = moment(data01, 3);
mmoment_3
mmoment_central_3 = moment(data01, 3, "c");
mmoment_central_3
mmoment_central_absolute_3 = moment(data01, 3, "ac");
mmoment_central_absolute_3
mmoment_central_absolute_3 = moment(data01, 3, "a");
mmoment_central_absolute_3
mmoment_raw_3 = moment(data01, 3, "r");
mmoment_raw_3
mmoment_raw_absolute_3 = moment(data01, 3, "ar");
mmoment_raw_absolute_3
disp ("----------------------------------------------------------------------------------")
mmoment_32 = moment(data01, 3.2);
mmoment_32
mmoment_central_32 = moment(data01, 3.2, "c");
mmoment_central_32
mmoment_central_absolute_32 = moment(data01, 3.2, "ac");
mmoment_central_absolute_32
mmoment_central_absolute_32 = moment(data01, 3.2, "a");
mmoment_central_absolute_32
mmoment_raw_32 = moment(data01, 3.2, "r");
mmoment_raw_32
mmoment_raw_absolute_32 = moment(data01, 3.2, "ar");
mmoment_raw_absolute_32
disp ("----------------------------------------------------------------------------------")
mmoment_5 = moment(data01, 5);
mmoment_5
mmoment_central_5 = moment(data01, 5, "c");
mmoment_central_5
mmoment_central_absolute_5 = moment(data01, 5, "ac");
mmoment_central_absolute_5
mmoment_central_absolute_5 = moment(data01, 5, "a");
mmoment_central_absolute_5
mmoment_raw_5 = moment(data01, 5, "r");
mmoment_raw_5
mmoment_raw_absolute_5 = moment(data01, 5, "ar");
mmoment_raw_absolute_5
disp ("----------------------------------------------------------------------------------")
mmoment_55 = moment(data01, 5.5);
mmoment_55
mmoment_central_55 = moment(data01, 5.5, "c");
mmoment_central_55
mmoment_central_absolute_55 = moment(data01, 5.5, "ac");
mmoment_central_absolute_55
mmoment_central_absolute_55 = moment(data01, 5.5, "a");
mmoment_central_absolute_55
mmoment_raw_55 = moment(data01, 5.5, "r");
mmoment_raw_55
mmoment_raw_absolute_55 = moment(data01, 5.5, "ar");
mmoment_raw_absolute_55



