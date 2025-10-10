from functools import reduce

def step(state, cur):
    total_dis, total_hrs = state
    cur_speed, cur_hours = cur

    dt = cur_hours - total_hrs
    dis = cur_speed * dt
    step = total_dis + dis, total_hrs + dt

    return step

def calc(lst):
    pairs = zip(*[iter(lst)] * 2)
    return reduce(step, pairs, (0,0))

lst = [15,1,25,2,30,3,10,5]
dis, hours = calc(lst)
print(dis, hours)