
from Tests00Data import *
from scipy import stats
import statistics
import timeit

# https://docs.python.org/3/library/statistics.html
# https://docs.scipy.org/doc/scipy/reference/stats.html


print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
mode = "multi modal"
try:
    mode = statistics.mode(data)
except statistics.StatisticsError:
    print ("No unique mode found")
end = timeit.default_timer()
# Assert
print ("mode                          = ", mode)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
skewness = stats.skew(data)
end = timeit.default_timer()
# Assert
print ("skewness                      = ", skewness)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
kurtosis = stats.kurtosis(data)
end = timeit.default_timer()
# Assert
print ("kurtosis                      = ", kurtosis)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

    
print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
cumfreq = stats.cumfreq(data)
end = timeit.default_timer()
# Assert
print ("cumfreq                       = ", cumfreq)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
itemfreq = stats.itemfreq(data)
end = timeit.default_timer()
# Assert
print ("itemfreq                      = ", itemfreq)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")



