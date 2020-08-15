from scipy import stats
import statistics
import timeit

# samples from: https://docs.python.org/3/library/statistics.html

#==================================================================================
# Arrange
data = [1, 2, 3, 4, 4]
print ("data          = ", data)
start = timeit.default_timer()
# Act
mean_arithmetic = statistics.mean(data)
end = timeit.default_timer()
# Assert
print ("mean_arithmetic = ", mean_arithmetic)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(mean_arithmetic == 2.8)
#==================================================================================

#==================================================================================
# Arrange
data = [-1.0, 2.5, 3.25, 5.75]
print ("data          = ", data)
start = timeit.default_timer()
# Act
mean_arithmetic = statistics.mean(data)
end = timeit.default_timer()
# Assert
print ("mean_arithmetic = ", mean_arithmetic)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(mean_arithmetic == 2.625)
#==================================================================================

#==================================================================================
# Arrange
data = [2.5, 3, 10]
print ("data          = ", data)
start = timeit.default_timer()
# Act
mean_harmonic = stats.hmean(data)
end = timeit.default_timer()
# Assert
print ("mean_harmonic = ", mean_harmonic)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(mean_harmonic == 3.5999999999999996)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 5]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median = statistics.median(data)
end = timeit.default_timer()
# Assert
print ("median = ", median)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median == 3)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 5, 7]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median = statistics.median(data)
end = timeit.default_timer()
# Assert
print ("median = ", median)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median == 4)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 5]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_low = statistics.median_low(data)
end = timeit.default_timer()
# Assert
print ("median_low = ", median_low)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_low == 3)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 5, 7]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_low = statistics.median_low(data)
end = timeit.default_timer()
# Assert
print ("median_low = ", median_low)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_low == 3)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 5]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_high = statistics.median_high(data)
end = timeit.default_timer()
# Assert
print ("median_high = ", median_high)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_high == 3)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 5, 7]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_high = statistics.median_high(data)
end = timeit.default_timer()
# Assert
print ("median_high     = ", median_high)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_high == 5)
#==================================================================================

#==================================================================================
# Arrange
data = [52, 52, 53, 54]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_grouped = statistics.median_grouped(data)
end = timeit.default_timer()
# Assert
print ("median_grouped  = ", median_grouped)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_grouped == 52.5)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 2, 2, 3, 4, 4, 4, 4, 4, 5]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_grouped = statistics.median_grouped(data)
end = timeit.default_timer()
# Assert
print ("median_grouped  = ", median_grouped)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_grouped == 3.7)
#==================================================================================

# 
# https://help.gnome.org/users/gnumeric/stable/gnumeric.html#gnumeric-function-SSMEDIAN
# https://mail.gnome.org/archives/gnumeric-list/2011-April/msg00018.html
#==================================================================================
# Arrange
data = [1, 3, 3, 5, 7]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_grouped = statistics.median_grouped(data, interval=1)
end = timeit.default_timer()
# Assert
print ("median_grouped  = ", median_grouped)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_grouped == 3.25)
#==================================================================================

#==================================================================================
# Arrange
data = [1, 3, 3, 5, 7]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_grouped = statistics.median_grouped(data, interval=2)
end = timeit.default_timer()
# Assert
print ("median_grouped  = ", median_grouped)
print ("      time [us] = ", (end - start) * 100000)
assert(median_grouped == 3.5)
#==================================================================================

#==================================================================================
# Arrange
data = [7, 8, 8]
print ("data          = ", data)
start = timeit.default_timer()
# Act
median_grouped = statistics.median_grouped(data, interval=1)
end = timeit.default_timer()
# Assert
print ("median_grouped  = ", median_grouped)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(median_grouped == 7.75)
#==================================================================================




#==================================================================================
# Arrange
data = [1, 1, 2, 3, 3, 3, 3, 4]
print ("data          = ", data)
start = timeit.default_timer()
# Act
mode = statistics.mode(data)
end = timeit.default_timer()
# Assert
print ("mode            = ", mode)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(mode == 3)
#==================================================================================

#==================================================================================
# Arrange
data = ["red", "blue", "blue", "red", "green", "red", "red"]
print ("data          = ", data)
start = timeit.default_timer()
# Act
mode = statistics.mode(data)
end = timeit.default_timer()
# Assert
print ("mode            = ", mode)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(mode == "red")
#==================================================================================



#==================================================================================
# Arrange
data = [1.5, 2.5, 2.5, 2.75, 3.25, 4.75]
print ("data          = ", data)
start = timeit.default_timer()
# Act
pstdev = statistics.pstdev(data)
end = timeit.default_timer()
# Assert
print ("pstdev          = ", pstdev)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(pstdev - 0.98689) < 0.00001)
#==================================================================================

#==================================================================================
# Arrange
mu = statistics.mean(data)
start = timeit.default_timer()
# Act
pstdev = statistics.pstdev(data, mu)
end = timeit.default_timer()
# Assert
print ("pstdev          = ", pstdev)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(pstdev - 0.98689) < 0.00001)
#==================================================================================



#==================================================================================
# Arrange
data = [0.0, 0.25, 0.25, 1.25, 1.5, 1.75, 2.75, 3.25]
print ("data          = ", data)
start = timeit.default_timer()
# Act
pvariance = statistics.pvariance(data)
end = timeit.default_timer()
# Assert
print ("pvariance       = ", pvariance)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(pvariance - 1.25) < 0.001)
#==================================================================================

#==================================================================================
# Arrange
mu = statistics.mean(data)
start = timeit.default_timer()
# Act
pvariance = statistics.pvariance(data, mu)
end = timeit.default_timer()
# Assert
print ("pvariance       = ", pvariance)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(pvariance - 1.25) < 0.001)
#==================================================================================



#==================================================================================
# Arrange
data = [1.5, 2.5, 2.5, 2.75, 3.25, 4.75]
print ("data          = ", data)
start = timeit.default_timer()
# Act
stdev = statistics.stdev(data)
end = timeit.default_timer()
# Assert
print ("stdev           = ", stdev)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(stdev - 1.08108) < 0.00001)
#==================================================================================

#==================================================================================
# Arrange
mu = statistics.mean(data)
start = timeit.default_timer()
# Act
stdev = statistics.stdev(data, mu)
end = timeit.default_timer()
# Assert
print ("stdev           = ", stdev)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(stdev - 1.08108) < 0.00001)
#==================================================================================



#==================================================================================
# Arrange
data = [2.75, 1.75, 1.25, 0.25, 0.5, 1.25, 3.5]
print ("data          = ", data)
start = timeit.default_timer()
# Act
variance = statistics.variance(data)
end = timeit.default_timer()
# Assert
print ("variance        = ", variance)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(variance - 1.37202) < 0.00001)
#==================================================================================

#==================================================================================
# Arrange
mu = statistics.mean(data)
start = timeit.default_timer()
# Act
variance = statistics.variance(data, mu)
end = timeit.default_timer()
# Assert
print ("variance        = ", variance)
print (u"      time [\u00B5s] = ", (end - start) * 100000)
assert(abs(variance - 1.37202) < 0.00001)
#==================================================================================


