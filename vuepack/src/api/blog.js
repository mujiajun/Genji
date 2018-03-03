import request from '@/utils/request'

export function getBlogList(params) {
  return request({
    url: '/blog/getlist',
    method: 'post',
    params
  })
}

export function addNewBlog(params) {
  return request({
    url: '/blog',
    method: 'post',
    params
  })
}