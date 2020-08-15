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
mean_arithmetic = statistics.mean(data)
end = timeit.default_timer()
# Assert
print ("mean_arithmetic               = ", mean_arithmetic)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
mean_geometric = stats.gmean(data)
end = timeit.default_timer()
# Assert
print ("mean_geometric                = ", mean_geometric)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
mean_harmonic = stats.hmean(data)
end = timeit.default_timer()
# Assert
print ("mean_harmonic                 = ", mean_harmonic)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
median = statistics.median(data)
end = timeit.default_timer()
# Assert
print ("median                        = ", median)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
moment = stats.moment(data)
end = timeit.default_timer()
# Assert
print ("moment                        = ", moment)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
median_low = statistics.median_low(data)
end = timeit.default_timer()
# Assert
print ("median_low                    = ", median_low)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
median_high = statistics.median_high(data)
end = timeit.default_timer()
# Assert
print ("median_high                   = ", median_high)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

print ("==================================================================================")
# Arrange
start = timeit.default_timer()
# Act
median_grouped = statistics.median_grouped(data)
end = timeit.default_timer()
# Assert
print ("median_grouped                = ", median_grouped)
print (u"              time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
print ("==================================================================================")

