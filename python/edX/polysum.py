import math

def polysum(n, s):
    """
    :param n: value of n
    :param s: value of s
    :return: the polysum for n, s
    """
    area = (0.25 * n * s**2) / math.tan(math.pi / n)
    perim = s * n
    return round(area + perim ** 2, 4)


print(polysum(10,94))
