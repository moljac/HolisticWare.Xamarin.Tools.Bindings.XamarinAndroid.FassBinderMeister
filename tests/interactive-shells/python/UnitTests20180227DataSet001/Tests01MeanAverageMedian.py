
from Tests00Data import *
from scipy import stats
import statistics
import timeit

# https://docs.python.org/3/library/statistics.html

#==================================================================================
# Arrange
print ("data          = ", data)

start = timeit.default_timer()
# Act
mean_arithmetic = statistics.mean(data)
end = timeit.default_timer()
# Assert
print ("mean_arithmetic = ", mean_arithmetic)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
#==================================================================================

mean_harmonic = stats.hmean(data)
print ("mean_harmonic   = ", mean_harmonic)

mean_arithmetic = statistics.mean(data)
print ("mean_arithmetic = ", mean_arithmetic)

mean_harmonic = stats.hmean(data)
print ("mean_harmonic   = ", mean_harmonic)

mode = statistics.mode(data)
print ("mode  = ", mode)

median = statistics.median(data)
print ("median          = ", median)

median_low = statistics.median_low(data)
print ("median_low      = ", median_low)

median_high = statistics.median_high(data)
print ("median_high     = ", median_high)

median_grouped = statistics.median_grouped(data)
print ("median_grouped  = ", median_grouped)

