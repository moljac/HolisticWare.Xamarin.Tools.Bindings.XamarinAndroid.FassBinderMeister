
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
mean_arithmetic = statistics.kurtosis(data, None, True, False, 'propagate')
end = timeit.default_timer()
# Assert
print ("mean_arithmetic = ", mean_arithmetic)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
#==================================================================================

#==================================================================================
# Arrange
print ("data          = ", data)

start = timeit.default_timer()
# Act
mean_arithmetic = statistics.kurtosis(data, None, False, False, 'propagate')
end = timeit.default_timer()
# Assert
print ("mean_arithmetic = ", mean_arithmetic)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
#assert(mean_arithmetic == 3.8)
#==================================================================================


